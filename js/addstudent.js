
$(document).ready(function () {
    // When PaymentType changes
    // PaymentType change logic
    $("#PaymentType").change(function () {
        var paymentType = $(this).val();

        if (paymentType === "Cash" || paymentType === "Online") {
            $("#Amount").val("200");
        } else {
            $("#Amount").val("");
        }

        // Update background color according to status
        var status = $("#Status").val();
        if (status === "Paid") {
            $("#Amount").css({
                "background-color": "green",
                "color": "white"
            });
        } else if (status === "Due") {
            $("#Amount").css({
                "background-color": "red",
                "color": "white"
            });
        } else {
            $("#Amount").css({
                "background-color": "white",
                "color": "black"
            });
        }
    });

    // Status change logic
    $("#Status").change(function () {
        var status = $(this).val();

        if (status === "Paid") {
            $("#Amount").css({
                "background-color": "green",
                "color": "white"
            });
        } else if (status === "Due") {
            $("#Amount").css({
                "background-color": "red",
                "color": "white"
            });
        } else {
            $("#Amount").css({
                "background-color": "white",
                "color": "black"
            });
        }
    });

    // List of input field names that should allow only letters and spaces
    var stringFields = ["Name", "FatherName", "MotherName", "Religion", "Nationality", "FatherOccupation", "MotherOccupation"];

    stringFields.forEach(function (fieldName) {
        $("input[name='" + fieldName + "']").on('input', function () {
            var regex = /^[a-zA-Z\s]*$/;
            if (!regex.test($(this).val())) {
                $(this).addClass('is-invalid');
                if ($(this).next('.invalid-feedback').length === 0) {
                    $(this).after('<div class="invalid-feedback">Only letters are allowed</div>');
                }
            } else {
                $(this).removeClass('is-invalid');
                $(this).next('.invalid-feedback').remove();
            }
        });
    });
    // List of numeric fields (int) names from your model
    var numericFields = ["Roll", "Amount", "AdmissionNo", "Phone"]; // Add any other numeric fields here

    numericFields.forEach(function (fieldName) {
        $("input[name='" + fieldName + "']").on('input', function () {
            var regex = /^\d*$/; // only digits allowed
            if (!regex.test($(this).val())) {
                $(this).addClass('is-invalid');
                if ($(this).next('.invalid-feedback').length === 0) {
                    $(this).after('<div class="invalid-feedback">Only numbers are allowed</div>');
                }
            } else {
                $(this).removeClass('is-invalid');
                $(this).next('.invalid-feedback').remove();
            }
        });
    });


   
        $(document).ready(function () {
            $('#Class').change(function () {
                var selectedClass = $(this).val();
                if (selectedClass) {
                    $.ajax({
                        url: '/Student/GetNextRoll',
                        type: 'GET',
                        data: { classNumber: selectedClass },
                        success: function (data) {
                            $('#Roll').val(data.roll);
                        },
                        error: function () {
                            alert('Could not fetch next roll number');
                        }
                    });
                } else {
                    $('#Roll').val('');
                }
            });
        })
    $(document).ready(function () {
        $('#Class').change(function () {
            var selectedClass = $(this).val();
            if (selectedClass) {
                $.ajax({
                    url: '/Student/GetNextAdmissionNo',
                    type: 'GET',
                    data: { className: selectedClass },
                    success: function (data) {
                        $('#AdmissionNo').val(data.admissionNo);
                    },
                    error: function () {
                        alert('Could not generate Admission No');
                    }
                });
            } else {
                $('#AdmissionNo').val('');
            }
        });
    });
    


});