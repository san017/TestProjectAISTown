deleteTableRowDynamically("tableBankAccount", "bankAccount-", "/BankAccount/Delete")
deleteTableRowDynamically("tableOperationBankAccount", "operationAccount-", "/OperationBankAccount/Delete")


/**
 * �������� ������ �� ������� � Html ��������.
 * @param {id �������} tableId
 * @param {����� id ��������� ������} inputIdPart
 * @param {���� � ����������� ��������} url
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
 * �������� �������� �� ������� ��.
 * @param {���� � �������� ��������} url
 * @param {Id ��������� ������} idInput
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