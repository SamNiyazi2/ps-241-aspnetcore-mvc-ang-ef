
// 08/23/2020 07:52 pm - SSN - [20200823-1952] - [001] - M04-05 - Using NPM 


//$(document).ready(function () {});


function setupValidationSummaryErrors() {

    setTimeout(setupValidationSummaryErrors_setup, 2000);

}

function setupValidationSummaryErrors_setup() {



    $(".validation-summary-errors li").bind('click', function (e) {
        let textMessage = $(this).text();

        $(".form-control").each(function (ndx, obj1) {
            $.each(this.attributes, function (i, attribute) {

                if (attribute.nodeName.startsWith('data-val-')) {

                    if (textMessage === attribute.nodeValue) {

                        $(this.ownerElement).focus();
                    }
                }
            });
        });
    });

    $(".validation-summary-errors li").each(function (i, obj1) {
        $(obj1).addClass('cssLinkedErrorMessage');
    });

}


$(function () {

 
    $('[defaultFocus]').focus();
});
