function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $('#firsttab').html(response);
            }
        })
    }
    return false;
}