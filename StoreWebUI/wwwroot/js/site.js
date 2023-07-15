// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let element = document.getElementById("p-info");
function Search() {
    var value = document.getElementById("searchInput").value;
    if (String(value).trim() == '') {
        alert('Please use Barcode Scanner');
    }
    else {
        $.ajax({
            url: `https://localhost:22950/s/${value}`,
            method: "GET",
            success: function (data) {
                console.log(data);
                let content = `
                <section>
<img  src='${data.imageUrl}' style='width:100px;height:100px;'/>
<h1>Name : ${data.productName}</h1>
<section>
<h5>Code : ${data.code}</h5>
<h5>Volume : ${data.volume}</h5>
<h4><b>Total Price : ${data.totalPrice}$</b></h5>
</section>
</section>
`;
                element.innerHTML+= content;
            }
        })
    }
}



function addProduct() {
    var response = getUploadedImage();
    response.then((d) => {
        console.log(d);
        const name = document.getElementById("product").value;
    const price = document.getElementById("price").value;
    const quantity = document.getElementById("quantity").value;

    let obj = {
        "id": 0,
        "name": name,
        "price": Number(price),
        "quantity": Number(quantity),
        "imageUrl":d
        };
        console.log("Object");
        console.log(obj);

    $.ajax({
        url: "https://localhost:22950/p",
        method: "POST",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            location.href = 'https://localhost:7189/';
            alert("Product Added Successfully");
        }
    })
    }, error => alert(error));


    
}
var PATH = "";
function getUploadedImage() {

    var fileInput = document.getElementById('MyImage');
    console.log(fileInput.files);
    if (fileInput.files.length == 0) {
        return "https://www.wdmtech.com/demo/images/stories/virtuemart/product/product_lg_type.jpg";
    }
    var file = fileInput.files[0];
    var formData = new FormData();
    formData.append('file', file);


    return $.ajax({
        url: 'https://localhost:22950/i',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            return response;
        },
        error: function () {
            console.error('Request failed');
        }
    });
}


CallGetAll();

var products=[];
function CallGetAll() {
    $.ajax({
        url: "https://localhost:22950/p",
        method: "GET",
        success: function (data) {

            let content = "";
            for (var i = 0; i < data.length; i++) {
                let item = `
<div class="card" style="width: 18rem;">
     <img class="card-img-top" src="${data[i].imageUrl}" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">${data[i].name}</h5>
    <p class="card-text">${data[i].price}$</p>
    <a onclick="SelectProduct(${data[i].id})" class="btn btn-primary">Select Product</a>
  </div>
</div>
`;
                content += item;
            }
            products = data;
            console.log(products);
            $("#products").html(content);
        }
    })
}

var selectedProduct;
function SelectProduct(id) {
    $("#productId").val(id);
    selectedProduct = products.find(p => p.id == id);
    console.log(selectedProduct);
}

function GetBarcode() {
    let volume = $("#volumeId").val();
    let obj = {
        "productId": selectedProduct.id,
        "volume": volume,
        "price": selectedProduct.price,
        "productName": selectedProduct.name
    }
    console.log(obj);
    $.ajax({
        url: "https://localhost:22950/b",
        method: "POST",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#result").html(data);
        }
    })
}