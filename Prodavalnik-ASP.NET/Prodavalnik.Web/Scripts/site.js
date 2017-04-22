$(document).ready(function () {
    $('select.fields-select').change(function () {
        var orderId = $(this).val();
        if (orderId == 2) {
            $('.cat')
                .after('<div class="form-group cat-option"><div class="col-md-3"><select class="form-control"><option>Блузи</option></select></div></div>');
        } else {
            $('.cat-option').hide();
        }
    });
});