$(document).ready(function () {

    $('#btnSubmit').click(function () {

        var value = $('#txtApplicantNo').val();
        if (value.length == 0) {
            $("#tblResult").hide();
            $("#tblNoData").hide();
            alert('Please enter Applicant no');
        }

        $.ajax({
            type: "GET",
            url: "/Recruitment/Get",
            data: {
                applicantNo: $('#txtApplicantNo').val()
            },
            success: function (result) {
                $('#tblResult tbody').empty();
                if ($.trim(result)) {
                    $("#tblResult").show();
                    $("#tblNoData").hide();
                    result = $.parseJSON(result);
                    $.each(result, function (i, item) {
                        var rows = "<tr>"
                            + "<td>" + item.workFlowName + "</td>"
                            + "<td>" + ((item.status) ? "Passed" : "Failed") + "</td>"
                            + "</tr>"

                        $("#tblResult tbody").append(rows);
                    });
                }
                else {
                    $("#tblResult").hide();
                    $("#tblNoData").show();
                }
            },
            error: function (data) {
            }
        });
    });
});