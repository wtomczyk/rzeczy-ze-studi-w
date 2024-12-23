import logo from './logo.svg';
import './App.css';
import Main from './components/Main';
import Glowna from './components/Glowna';
import Trzecia from './components/Trzecia'
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <Router>
          <Routes>
            <Route path="/" element={<Main />} />
            <Route path="/Home" element={<Main />} />
            <Route path="/Glowna" element={<Glowna />} />
            <Route path="/Trzecia" element={<Trzecia />} />
          </Routes>
        </Router>
    </div>
  );
}

export default App;
