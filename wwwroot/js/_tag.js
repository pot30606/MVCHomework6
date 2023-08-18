
$(document).ready(function () {
    $.ajax({
        url: '/Home/TagPartial',
        type: 'GET',
        success: function (result) {
            console.log("result", result);
            if (result) {
                var htmlContent = '';
                result.forEach(item => {
                    let _html = `<li class="list-inline-item"><button type="button" class="btn">${item.name}<span class="badge bg-secondary">${item.amount}</span></button></li>`;
                    htmlContent += _html;
                });
                $('#tagContainer').html(htmlContent);
            }

        }
    });
});
