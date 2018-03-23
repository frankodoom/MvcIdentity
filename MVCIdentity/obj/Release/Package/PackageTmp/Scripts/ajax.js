
//Ajax Get Request
function getJson() {
    $.ajax({
        url: "/Ajax/AjaxGet",
        method: "Get",
        contentType: "json",
        cache: false,
        success: function (response) {
            var myResponse = response.message;
            alert(response);
            alert(myResponse);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

var valuesArray = $("select[name=faculty]").val();
function postJson() {
    $.ajax({
        url: "/Ajax/AjaxPost",
       // data:  ,
        method: "Post",
        contentType: " contentType: application/json charset=utf-8", //"application/x-www-form-urlencoded"

        cache: false,
        success: function (response) {
            var myResponse = response.message;
            alert(response);
            alert(myResponse);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

var form = $("#studentForm");
var formData = new FormData(form);
var serialisedFormObject = form.serialisedFormObject();

function postForm () {
    e.preventDefault();
    $.ajax({
        method: "post",
        data: serializedForm,
        url: "/Ajax/AjaxPost",
        contentType: " contentType: application/json",
        dataType: "Json", //datatype expected from the server
        //contentType: "application/x-www-form-urlencoded",
        cache: false,
        success: function (data) {

        },

        error: function (xhr, status, error) {

        }
    });
};



//$("#studentForm").submit(function () {
//    e.preventDefault();
//    $.ajax({
//        method: "post",
//        data: $(this).serialize(),
//        url: "/Ajax/AjaxPost",
//        contentType: " contentType: application/json",
//        dataType: "Json", //datatype expected from the server

//        //contentType: "application/x-www-form-urlencoded",
//        cache: false,
//        success: function () {


//        },

//        error: function (xhr, status, error) {


//        }
//    });
//}
//);