// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var infoBox = document.querySelector(".info-box");
var infoBoxStyle = infoBox.style;
var cookieOptions = document.querySelector(".cookie-options");
var cookieOptionsStyle = cookieOptions.style;

// Função para alternar a visibilidade da infoBox
function toggleInfoBox() {
    cookieOptionsStyle.display = 'none';
    if (infoBoxStyle.display === 'block') {
        infoBoxStyle.display = 'none';
        console.log("none");
    } else {
        infoBoxStyle.display = 'block';
        console.log("block");
    }
}

// Função para alternar entre infoBox e cookieOptions
function toggleCookieOptions() {
    if (infoBoxStyle.display === 'block') {
        infoBoxStyle.display = 'none';
        cookieOptionsStyle.display = 'block';
    } else {
        infoBoxStyle.display = 'block';
        cookieOptionsStyle.display = 'none';
    }
}

function cookieAccept(){
    cookieOptionsStyle.display = 'none';
}

function cookieReject(){
    cookieOptionsStyle.display = 'none';
}

function infoBoxAccept(){
    infoBoxStyle.display = 'none';
}

function infoBoxReject(){
    infoBoxStyle.display = 'none';
}
// Mascara CPF CNPJ
function mascaraMutuario(o,f){
    v_obj=o
    v_fun=f
    setTimeout('execmascara()',1)
}
 
function execmascara(){
    v_obj.value=v_fun(v_obj.value)
}
 
function cpfCnpj(v){
 
    //Remove tudo o que não é dígito
    v=v.replace(/\D/g,"")
 
    if (v.length <= 14) { //CPF
 
        //Coloca um ponto entre o terceiro e o quarto dígitos
        v=v.replace(/(\d{3})(\d)/,"$1.$2")
 
        //Coloca um ponto entre o terceiro e o quarto dígitos
        //de novo (para o segundo bloco de números)
        v=v.replace(/(\d{3})(\d)/,"$1.$2")
 
        //Coloca um hífen entre o terceiro e o quarto dígitos
        v=v.replace(/(\d{3})(\d{1,2})$/,"$1-$2")
 
    } else { //CNPJ
 
        //Coloca ponto entre o segundo e o terceiro dígitos
        v=v.replace(/^(\d{2})(\d)/,"$1.$2")
 
        //Coloca ponto entre o quinto e o sexto dígitos
        v=v.replace(/^(\d{2})\.(\d{3})(\d)/,"$1.$2.$3")
 
        //Coloca uma barra entre o oitavo e o nono dígitos
        v=v.replace(/\.(\d{3})(\d)/,".$1/$2")
 
        //Coloca um hífen depois do bloco de quatro dígitos
        v=v.replace(/(\d{4})(\d)/,"$1-$2")
 
    }
 
    return v
 
}

// function toggleFields() {
//     var isCpfChecked = document.getElementById("cpf").checked;
//     document.getElementById("cpfFields").style.display = isCpfChecked ? "block" : "none";
//     document.getElementById("cnpjFields").style.display = isCpfChecked ? "none" : "block";
// }

// Inicializa os campos corretos no carregamento

