deleteTableRowDynamically("tableBankAccount", "bankAccount-", "/BankAccount/Delete")
deleteTableRowDynamically("tableOperationBankAccount", "operationAccount-", "/OperationBankAccount/Delete")


/**
 * Удаление строки из таблицы в Html разметке.
 * @param {id таблицы} tableId
 * @param {часть id удаляемой строки} inputIdPart
 * @param {Путь к контроллеру удаления} url
 */
function deleteTableRowDynamically(tableId, inputIdPart, url) {

    var table = document.getElementById(tableId);

    if (table != null) {
        for (i = 0; i < table.rows.length - 1; i++) {
            var buttonDelete = document.getElementById("deleteButton-" + i);

            buttonDelete.addEventListener("click", (e) => {
                var numberRow = e.target.id.split("-")[1];

                var idRow = document.getElementById(inputIdPart + numberRow).value;
                deleteEntity(url, idRow);
                var deleteRow = document.getElementById("tableRow-" + numberRow);
                deleteRow.parentNode.removeChild(deleteRow);
            })

        }
    }
}

/**
 * Удаление сущности из таблицы БД.
 * @param {Путь к действию удаления} url
 * @param {Id удаляемой записи} idInput
 */
function deleteEntity(url, idInput) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(idInput),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            console.log("ok")
        }
    });
}