import React from "react";
import CrudPadrao from "../CrudPadrao.jsx";
import { getCursos, getCursoById, createCurso, updateCurso, deleteCurso} from "../../services/cursoService.js";

function Cursos() {
  const campos = ["nome", "descricao", "vagasDisponiveis"];
  const labels = {
    id: "ID",
    nome: "Nome",
    descricao: "Descrição",
    vagasDisponiveis: "Vagas Disponíveis"
  };

  return (
    <CrudPadrao
      titulo="Cursos"
      campos={campos}
      labels={labels}
      getTodos={getCursos}
      getById={getCursoById}
      post={createCurso}
      put={updateCurso}
      remove={deleteCurso}
    />
  );
}

export default Cursos;
