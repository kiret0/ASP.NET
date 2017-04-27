//$(document).ready(function () {
//    $('select.fields-select').change(function () {
//        var orderId = $(this).val();
//        if (orderId == 2) {
//            $('.cat')
//                .after('<div class="form-group cat-option"><div class="col-md-3"><select class="form-control"><option>Блузи</option></select></div></div>');
//        } else {
//            $('.cat-option').hide();
//        }
//    });
//});
$(document).ready(function () {
    document.getElementById('search').onclick(function() {
        document.getElementById('box').append(document.createElement('div')
            .appendChild(document.createElement('h3').textContent("fsfsfsfsfsdfsf")));
    });
//    $('input#search').click(function () {
//        $('.box').append("<div><h3>Немерини @Model.previewAdViewModels.Count() обяви</h3</div>");
//    });
});

