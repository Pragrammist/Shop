



function CreatBlog() {
    var elements = GetContent();
    var blogHtml = GetBlogHtml(elements);
    var previewElements = GetPreviewElements(elements);
    SendHtml(blogHtml, previewElements);
}


function GetContent() {
    var form = GetFormElements();
    var elements = [];
    var index = -1;
    for (var i = 0; i < form.length - 1; i++) {
        index++;
        if (form[i].name !== "__RequestVerificationToken") {
            
            var tag = form[i].name;
            var content = form[i].value;

            var element = {};
            element.tag = tag;

            element.content = content;
            elements[index] = element;
            
        }
        else {
            index--;
        }
    }
    return elements;
}
function GetFormElements() {
    var form = document.forms.item(0);
    return form;
}
function GetBlogHtml(elements) {
    let blog = document.createElement("div");
    blog.className = "ArticleContent";
    
    for (var i = 0; i < elements.length; i++) {
        var iElement = elements[i];
        var htmlElement;
        var htmlTag;
        var elementClassName = "";
        var htmlInnerContent = iElement.content;
        if (iElement.tag == "title") {
            htmlTag = "h1";
            elementClassName = "H1";  
        }
        else if (iElement.tag == "titleComment") {
            htmlTag = "h2";
            elementClassName = "H2";
        }
        else if (iElement.tag == "mainImg") {
            htmlTag = "img";
        }
        else if (iElement.tag.indexOf("img") !== -1) {
            htmlTag = "img"
        }
        else if (iElement.tag.indexOf("subtitle") !== -1) {
            htmlTag = "h3";
            elementClassName = "H3";
        }
        else if (iElement.tag.indexOf("paragraph") !== -1) {
            htmlTag = "p";
            elementClassName = "P";
        }
        htmlElement = document.createElement(htmlTag);
        htmlElement.className = elementClassName;
        if (iElement.tag.toLowerCase().indexOf("img") !== -1) {
            htmlElement.setAttribute("src", htmlInnerContent);
        }
        else {
            htmlElement.innerHTML = htmlInnerContent;
        }
        blog.append(htmlElement);
    }
    return blog.outerHTML;
}
function GetPreviewElements(elements) {
    var previewElements = {
        title: "",
        titleComment: "",
        mainImg: ""
    }

    for (var i = 0; i < elements.length; i++) {
        var iElement = elements[i];
        if (iElement.tag == "title") {
            previewElements.title = iElement.content;
        }
        else if (iElement.tag == "titleComment") {
            previewElements.titleComment = iElement.content;
        }
        else if (iElement.tag == "mainImg") {
            previewElements.mainImg = iElement.content;
        }
            //Заготовка
        else if (iElement.tag.indexOf("img") !== -1) {
            
        }
        else if (iElement.tag.indexOf("subtitle") !== -1) {
            
        }
        else if (iElement.tag.indexOf("paragraph") !== -1) {
            
        }
        
        
        
        
    }
    return previewElements;
}

function SendHtml(blog, previewElements) {
    var formData = new FormData();
    formData.append("html", blog);
    formData.append("title", previewElements.title);
    formData.append('titleComment', previewElements.titleComment);
    formData.append('mainImg', previewElements.mainImg);

    var request = new XMLHttpRequest();

    request.open("POST", "CreateArticle");
    request.send(formData);
     
}