import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Candidatos from "../src/components/pages/Candidatos.jsx";
import Inscricoes from "../src/components/pages/Inscricoes.jsx";
import ProcessosSeletivos from "../src/components/pages/ProcessosSeletivos.jsx";
import Cursos from "../src/components/pages/Cursos.jsx";

function App() {
  return (
    <Router>
      <div className="p-6">
        <nav className="mb-6 flex gap-4">
          <Link to="/candidatos" className="text-blue-600 hover:underline">Candidatos</Link>
          <Link to="/inscricoes" className="text-blue-600 hover:underline">Inscrições</Link>
          <Link to="/processos" className="text-blue-600 hover:underline">Processos Seletivos</Link>
          <Link to="/cursos" className="text-blue-600 hover:underline">Cursos</Link>
        </nav>
        <Routes>
          <Route path="/candidatos" element={<Candidatos />} />
          <Route path="/inscricoes" element={<Inscricoes />} />
          <Route path="/processos" element={<ProcessosSeletivos />} />
          <Route path="/cursos" element={<Cursos />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
