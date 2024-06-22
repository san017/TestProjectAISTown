using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProjectAISTown.DataContext;
using TestProjectAISTown.DataContext.Entities;
using TestProjectAISTown.Models.BankAccountOperations;
using TestProjectAISTown.Models.Input;
using TestProjectAISTown.Utilities;

namespace TestProjectAISTown.Controllers
{
    public class OperationBankAccountController : Controller
    {

        private readonly AppDBContext _dbContext;

        public OperationBankAccountController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Список операций по банковскому счёту.
        /// </summary>
        /// <param name="idBankAccount">id банковского счёта.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <returns>Страница со списком операций по банковскому счёту.</returns>
        public async Task<IActionResult> OperationBankAccountInfo(Guid idBankAccount, int? pageNumber)
        {
            if (idBankAccount == Guid.Empty)
            {
                return BadRequest();
            }

            int pageSize = 8;

            var operationsBankAccount = _dbContext.OperationBankAccounts
                .Where(x => x.BankAccountId == idBankAccount)
                .Select(x => new OperationBankAccountInfo
                {
                    OperationId = x.Id,
                    AccountNumber = x.BankAccount.AccountNumber,
                    OperationName = x.OperationType.TypeOperationName,
                    DateOperation = x.DateOperation
                });

            var model = new OperationBankAccountViewModel()
            {
                BankAccountId = idBankAccount,
                OperationBankAccountInfos = await PaginatedList<OperationBankAccountInfo>.CreateAsync(operationsBankAccount, pageNumber ?? 1, pageSize)
            };

            return View(model);
        }

        /// <summary>
        /// Создание операции для банковского счёта.
        /// </summary>
        /// <param name="idBankAccount">Id банковского счёта.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Create(Guid idBankAccount)
        {
            if (idBankAccount == Guid.Empty)
            {
                return BadRequest();
            }

            var dropList = new CreateNewOperationAccountModel()
            {
                OperationTypes = await _dbContext.OperationTypes.ToListAsync(),
                IdBankAccount = idBankAccount
            };

            return View(dropList);
        }

        /// <summary>
        /// Создание операции для банковского счёта.
        /// </summary>
        /// <param name="operationBankAccountInfo">Информация об операции банковского счёта.</param>
        /// <param name="idBankAccount">Id банковского счёта.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(OperationBankAccountInfo operationBankAccountInfo, Guid idBankAccount)
        {
            if (operationBankAccountInfo == null)
            {
                return BadRequest();
            }

            if (idBankAccount == Guid.Empty)
            {
                return BadRequest();
            }

            var operationAccount = new OperationBankAccount()
            {
                BankAccountId = idBankAccount,
                DateOperation = DateTime.Now,
                OperationTypeId = operationBankAccountInfo.OperationTypeId
            };


            _dbContext.Add(operationAccount);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("OperationBankAccountInfo", new { idBankAccount });
        }

        /// <summary>
        /// Редактирование существующей операции банковского счёта.
        /// </summary>
        /// <param name="id">Id операции.</param>
        /// <returns>Страница редактирования текущего счёта.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var operationBankAccount = await _dbContext.OperationBankAccounts.FindAsync(id);

            var currentOperationBankAccount = new EditOperationBankAccountModel()
            {
                OperationBankAccount = operationBankAccount,
                OperationTypes = await _dbContext.OperationTypes.ToListAsync()
            };

            return View(currentOperationBankAccount);
        }

        /// <summary>
        /// Редактирование существующей операции банковского счёта.
        /// </summary>
        /// <param name="operationBankAccount">Редактируемая операция.</param>
        /// <param name="idBankAccount">Id банковского счёта.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(OperationBankAccount operationBankAccount, Guid idBankAccount)
        {
            if (operationBankAccount == null)
            {
                return NotFound();
            }

            if (idBankAccount == Guid.Empty)
            {
                return BadRequest();
            }

            _dbContext.OperationBankAccounts.Update(operationBankAccount);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("OperationBankAccountInfo", new { idBankAccount });
        }

        /// <summary>
        /// Удаление операции.
        /// </summary>
        /// <param name="idRow">Id записи операции.</param>
        /// <returns>Json - объект с id записи.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Guid idRow)
        {
            if (idRow == Guid.Empty)
            {
                return BadRequest();
            }

            var operationBankAccount = await _dbContext.OperationBankAccounts.FirstOrDefaultAsync(x => x.Id == idRow);

            if (operationBankAccount == null)
            {
                return new EmptyResult();
            }

            _dbContext.OperationBankAccounts.Remove(operationBankAccount);
            await _dbContext.SaveChangesAsync();

            return Json(operationBankAccount.Id);
        }


    }
}
