
function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}
$(document).ready(function () {

    function addUserDataPost(form) {
        $.validator.unobtrusive.parse(form);
        if ($(form).valid()) {

            var ajaxConfig = {

                type: 'POST',
                url: form.action,
                data: new FormData(form),
                success: function (response) {
                    if (response.success) {
                        //alertify.success(response.message);
                        //alert("User Added successfully");
                        window.location.href = "http://localhost:13021/User";
                    }
                    else {
                        alertify.error(response.message);
                    }
                }
            }
            if ($(form).attr('enctype') == "multipart/form-data") {
                ajaxConfig["contentType"] = false;
                ajaxConfig["processData"] = false;
            }
            else {
                $.ajax(ajaxConfig);
            }
            
        }

        return false;
    }
});

function validateEmail(email) {

    //const re = "\\w+([-+.']\\w+)*@@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function Edit(url) {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {

        }
    });
}