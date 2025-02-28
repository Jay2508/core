function FillSubCategory(CatId, subCatId) {

    $.ajax({
        url: '/api/ProductTbl/SubCategoryList/' + CatId,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json; charset=UTF-8',
        success: function (response) {

            var SubCatData = $("#SubDrop");
            SubCatData.empty();
            SubCatData.append('<option value="">------SELECT SUBCATEGORY--------</option>');

            for (const item of response.data) {

                if (subCatId == item.subCatId) {

                    var option = `<option selected value="${item.subCatId}">${item.subCategory}</option>`;

                }
                else {
                    var option = `<option value="${item.subCatId}">${item.subCategory}</option>`;

                }

                $("#SubDrop").append(option);
            }

            console.log(response);
        },
        error: function (err) {
            console.log(err);
        }
    });
}
function FillThirdCategory(ThierCatId, ThSubCatId) {

    $.ajax({
        url: '/api/ProductTbl/ThierdCatList/' + ThierCatId,
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=UTF-8',
        success: function (response) {

            var ThierdCatData = $("#ThierdCatDrop");
            ThierdCatData.empty();
            ThierdCatData.append('<option value="">------SELECT THIERDCATEGORY--------</option>');

            for (var item of response.data) {
                if (ThSubCatId == item.thierdCatId) {

                    var option = `<option Selected value="${item.thierdCatId}">${item.thirdCategory}</option>`;

                }
                else {

                    var option = `<option value="${item.thierdCatId}">${item.thirdCategory}</option>`;
                }


                $("#ThierdCatDrop").append(option);
            }
            console.log(response);
        },
        error: function (err) {
            console.log(err);
        }

    });
}




