﻿function CarregaMascaras()
{
    $("#TelefoneCelular").mask("(99)9999-9999");
    $("#TelefoneFixo").mask("(99)9999-9999");
    $("#Cep").mask("99.999-999");
    //
}


function ComoSerTratado()
{
    if ($("#ComoSerTratadoID option:selected").val() == 6 || $("#ComoSerTratadoID option:selected").val() == 7) {

        $("#Apelido").css("display", "block");
    }

    $("#ComoSerTratadoID").click(function () {

        if ($("#ComoSerTratadoID option:selected").val() == 6 || $("#ComoSerTratadoID option:selected").val() == 7) {
            $("#Apelido").css("display", "block");
        }
        else {
            $("#Apelido").css("display", "none");
        }

    });
}

$("#Cep").keyup(function (event) {
    getEndereco();
});

function getEndereco() {
    // Se o campo CEP não estiver vazio
    if ($.trim($("#Cep").val()) != "") {

        http: //cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep="+$("#cep").val()


            $.getScript("http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $("#Cep").val(), function () {

                //Se o resultado for igual a 1
                if (resultadoCEP["resultado"]) {
                    // troca o valor dos elementos

                    $("#Endereco").val(unescape(resultadoCEP["tipo_logradouro"]) + ": " + unescape(resultadoCEP["logradouro"]));
                    $("#Bairro").val(unescape(resultadoCEP["bairro"]));
                    $("#CidadeID").val(unescape(resultadoCEP["cidade"]));

                    //var dropdown = document.getElementById('#EstadoID').options;
                    //for (var i = 0, L = dropdown.length; i < L; i++) {
                    //    if (dropdown[i].text == unescape(resultadoCEP["uf"])) {
                    //        document.getElementById('#EstadoID').selectedIndex = i;
                    //        break;
                    //    }
                    //}

                } else {
                    alert("Endereço não encontrado");
                }
            });
    }
}

function VerificaCPF(cpf) {
    if (cpf.value != '___.___.___-__') {
        if (!validarCPF(cpf.value)) {

            var botao = document.getElementById('<%=btnSalvar.ClientID%>');
            botao.disabled = true;
            alert('Número fora do formato.\nFavor insira um número correto.');
            $("#<%=txtCPF.ClientID%>").val('');

        }
        else {

            $.ajax({
                type: "POST",
                url: "Cadastro.aspx/postValidarCPF",
                data: "{ 'doc' : '" + cpf.value + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    $.each(response.d, function (index, item) {

                        if (index == 0) {

                            if (item == 'false') {

                                var botao = document.getElementById('<%=btnSalvar.ClientID%>');
                                botao.disabled = true;
                                alert('O CPF informado, já cadastrado em nossa base de dados.\n\nFavor informar outro número de documento.');

                            } else {

                                var botao = document.getElementById('<%=btnSalvar.ClientID%>');
                                botao.disabled = false;

                            }

                        }


                    });
                },
                error: function () {
                    alert("Falha ao carregar dados");
                }
            });


            }
    }
}