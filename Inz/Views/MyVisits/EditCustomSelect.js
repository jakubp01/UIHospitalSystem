document.addEventListener("DOMContentLoaded", function () {
    var doctorId = @Json.Serialize(Model.doctor.Id);
    var doctorSelect = document.getElementById("doctor.Id");

    var patientId = @Json.Serialize(Model.patient.Id);
    var patientSelect = document.getElementById("patient.Id");

    setDefaultOption(doctorSelect, doctorId);
    setDefaultOption(patientSelect, patientId);

    function setDefaultOption(selectElement, valueToSelect) {
        for (var i = 0; i < selectElement.options.length; i++) {
            if (selectElement.options[i].value == valueToSelect) {
                selectElement.options[i].selected = true;
                break;
            }
        }
    }
});