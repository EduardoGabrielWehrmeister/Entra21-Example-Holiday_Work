
$(function () {

    $("#campo-pesquisa").on("keyup", function (e) {
        // 13 == Tecla Enter do teclado
        if (e.keyCode == 13) {
            obterTodos();
        }
    });


    function obterTodos() {
        $busca = $("#campo-pesquisa").val();
        $("#lista-cidades").empty();
        $.ajax({
            url: '/cidade/obtertodos',
            method: 'get',
            data: {
                busca: $busca
            },
            success: function (data) {

                for (var i = 0; i < data.length; i++) {
                    var dado = data[i];

                   



                    var linha = document.createElement("tr");
                    var colunaCodigo = document.createElement("td");
                    colunaCodigo.innerHTML = dado.Id;

                    var ColunaNomeEstado = document.createElement("td");
                    colunaNomeEstado.innerHTML = dado.Cidade.Estado.Nome;           
                    
                    var ColunaNome = document.createElement("td");
                    ColunaNome.innerHTML = dado.Nome;


                    var colunaNumeroHabitante = document.createElement("td");
                    colunaNumeroHabitante.innerHTML = dado.NumeroHabitante;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");
                    botaoEditar.classList.add("btn", "btn-primary", "mr-3"
                        , "botao-editar");
                    botaoEditar.innerHTML =
                        "<i class=\"fas fa-pen\"></i> Editar";
                    botaoEditar.setAttribute("data-id", dado.Id);

                    var botaoApagar = document.createElement("button");
                    botaoApagar.innerHTML =
                        "<i class=\"fas fa-trash\"></i> Apagar";
                    botaoApagar.classList.add("btn", "btn-danger",
                        "botao-apagar");
                    botaoApagar.setAttribute("data-id", dado.Id);

                    colunaAcao.appendChild(botaoEditar);
                    colunaAcao.appendChild(botaoApagar);

                    linha.appendChild(colunaCodigo);
                    linha.appendChild(ColunaNomeEstado);
                    linha.appendChild(ColunaNome);
                    linha.appendChild(colunaNumeroHabitante);
                    linha.appendChild(colunaAcao);
                    if (document.getElementById("lista-cidades") != null) {
                        document.getElementById("lista-cidades").appendChild(linha);
                    }
                }

            },
            error: function (data) {
                alert("DEU RUIM");
            }
        })
    }

    obterTodos();
});