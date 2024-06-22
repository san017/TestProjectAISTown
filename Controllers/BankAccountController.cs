using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestProjectAISTown.DataContext;
using TestProjectAISTown.DataContext.Entities;
using TestProjectAISTown.Models;
using TestProjectAISTown.Models.BankAccounts;
using TestProjectAISTown.Models.Input;
using TestProjectAISTown.Utilities;

namespace TestProjectAISTown.Controllers
{
    public class BankAccountController : Controller
    {

        private readonly AppDBContext _dbContext;

        public BankAccountController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// C����� ���������� ������ � ������������ ���������� � �����������.
        /// </summary>
        /// <param name="pageNumber">����� ��������.</param>
        /// <param name="searchString">��������� ����� �����.</param>
        /// <returns>������ ���������� ������.</returns>
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {
            int pageSize = 8;
            var bankAccounts = _dbContext.BankAccounts.Select(x => new BankAccountViewModel
            {
                IdBankAccount = x.Id,
                AccountNumber = x.AccountNumber,
                Balance = x.Balance,
                CurrencyName = x.Currency.NameCurrency ?? string.Empty,
                CustomerName = x.Customer.ShortName ?? string.Empty,
                TypeName = x.TypeAccount.AccountTypeName,
                StatusName = x.Status.StatusName ?? string.Empty,
                SearchString = searchString
            });

            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                bankAccounts = bankAccounts.Where(s => s.AccountNumber.Contains(searchString));
            }

            return View(await PaginatedList<BankAccountViewModel>.CreateAsync(bankAccounts, pageNumber ?? 1, pageSize));
        }

        /// <summary>
        /// �������� ������ ����������� �����.
        /// </summary>
        /// <returns>������������� � ������������ ����������� ��������.</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dropList = new �reateNewAccountModel
            {
                SelectAccountTypeItems = await _dbContext.AccountTypes.ToListAsync(),
                SelectCurrencyItems = await _dbContext.Currencies.ToListAsync(),
                SelectCustomerItems = await _dbContext.Customers.ToListAsync(),
                SelectStatusAccountItems = await _dbContext.StatusAccounts.ToListAsync()
            };

            return View(dropList);
        }

        /// <summary>
        /// ���������� ������ �����.
        /// </summary>
        /// <param name="createNewBankAccountInfo">���������� � ��������� ������ � ���������� �����.</param>
        /// <returns>������� �� �������� �� ������� ���������� ������ � ����� ����������.</returns>

        [HttpPost]
        public async Task<IActionResult> Create(BankAccountInfo createNewBankAccountInfo)
        {
            if (createNewBankAccountInfo == null)
            {
                return BadRequest();
            }

            var bankAccount = new BankAccount()
            {
                AccountNumber = createNewBankAccountInfo.AccountNumber,
                Balance = createNewBankAccountInfo.Balance,
                AccountTypeId = createNewBankAccountInfo.AccountTypeId,
                CurrencyId = createNewBankAccountInfo.CurrencyId,
                CustomerId = createNewBankAccountInfo.CustomerId,
                StatusId = createNewBankAccountInfo.StatusId
            };

            _dbContext.Add(bankAccount);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        /// <summary>
        /// �������������� ������������� �����.
        /// </summary>
        /// <param name="id">������������� ������ ����������� �����.</param>
        /// <returns>�������� �������������� ���������� �����.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var bankAccount = await _dbContext.BankAccounts.FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            var currentBankAccount = new EditBankAccountModel()
            {
                BankAccount = bankAccount,
                AccountTypes = await _dbContext.AccountTypes.ToListAsync(),
                Customers = await _dbContext.Customers.ToListAsync(),
                Currencies = await _dbContext.Currencies.ToListAsync(),
                StatusAccounts = await _dbContext.StatusAccounts.ToListAsync()
            };

            return View(currentBankAccount);

        }

        /// <summary>
        /// �������������� �������� �����.
        /// </summary>
        /// <param name="bankAccount">���������� ����.</param>
        /// <returns>������� �� �������� ������ ���������� ������ � ���������� ������.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                return NotFound();
            }

            _dbContext.BankAccounts.Update(bankAccount);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// �������� ����������� ����� �� �������.
        /// </summary>
        /// <param name="idRow">������������� ������.</param>
        /// <returns>Json - ������ � id ������.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Guid idRow)
        {
            if (idRow == Guid.Empty)
            {
                return BadRequest();
            }

            var bankAccount = await _dbContext.BankAccounts.FirstOrDefaultAsync(x => x.Id == idRow);

            if (bankAccount == null)
            {
                return new EmptyResult();
            }

            _dbContext.BankAccounts.Remove(bankAccount);
            await _dbContext.SaveChangesAsync();


            return Json(bankAccount.Id);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
