
var numForms = 0;
var numP = 0;
var numPh = 0;
var numSubT = 0;

var dropdown = document.getElementsByClassName("dropdown");
function AddFormItem(item) {
    var form = document.getElementById("creatorForm");
    form.appendChild(item);
}
function ClickEvenButton(obj) {
    var InputElementForm;
    if (obj.id == "AddP") {
        InputElementForm = GetElementForm("P");
    }
    else if (obj.id == "AddPh") {
        InputElementForm = GetElementForm("Ph");
    }
    else if (obj.id == "AddSubT") {
        InputElementForm = GetElementForm("SubT");
    }
    AddFormItem(InputElementForm);
}
function GetElementForm(strItem) {
    var InputElementForm = document.createElement("textarea");
    numForms++;
    if (strItem == "P") {
        numP++;
        InputElementForm.name = "paragraph" + numP;
        InputElementForm.style.minHeight = "130px";
        InputElementForm.style.fontFamily = "Verdana";
        InputElementForm.style.fontSize = "20px";
        InputElementForm.placeholder = "Введите текст для парафграфа";
    }
    else if (strItem == "Ph") {
        numPh++;
        InputElementForm.name = "img" + numPh;
        InputElementForm.type = "img";
        InputElementForm.rows = 1;
        InputElementForm.style.minHeight = "30px";
        InputElementForm.style.maxHeight = "30px";
        InputElementForm.style.fontStyle = "italic";
        InputElementForm.placeholder = "Введите ссылку на фотографию";
    }
    else if (strItem == "SubT") {
        numSubT++;
        InputElementForm.name = "subtitle" + numSubT;
        InputElementForm.style.minHeight = "48px";
        InputElementForm.style.fontSize = "40px";
        InputElementForm.style.fontWeight = "bold";
        InputElementForm.style.fontFamily = "Times New Roman";
        InputElementForm.placeholder = "Введите подзаголовок";
    }
    InputElementForm.name += "N" + numForms;
    return InputElementForm;
}