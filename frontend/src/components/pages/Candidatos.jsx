import CrudPadrao from "../CrudPadrao.jsx";
import {
  getCandidatos,
  getCandidatoById,
  createCandidato,
  updateCandidato,
  deleteCandidato
} from "../../services/candidatoService";

function Candidatos() {
  return (
    <CrudPadrao
      titulo="Candidatos"
      campos={["nome", "email", "telefone", "cpf"]}
      labels={{
        nome: "Nome",
        email: "Email",
        telefone: "Telefone",
        cpf: "CPF"
      }}
      getTodos={getCandidatos}
      getById={getCandidatoById}
      post={createCandidato}
      put={updateCandidato}
      remove={deleteCandidato}
    />
  );
}

export default Candidatos;
