function FillSubCategory(CatId, SubCatId) {
    $.ajax({
        url: '/api/ThierdCateGoryTbl/SubCategoryList/'+ CatId,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json; charset=UTF-8',
        success: function (response) {
         

            var SubCatData = $("#SubDrop");
            SubCatData.empty();
            SubCatData = '<option value="0">------SELECT SUBCATEGORY--------</option>';
           


            for (const item of response.data) {
                if (SubCatId == item.SubCatId) {

                    var option = `<option selected value="${item.SubCatId}">${item.SubCategoryName}</option>`;
                }
                else {
                    var Row = `<option value="${item.subCatId}">${item.subCategory}</option>`;

                }
                $("#SubDrop").append(Row);
            }

            console.log(response);

        },
        error: function (err) {
            console.log(err);
        }
    });
}


