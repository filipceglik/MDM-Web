import logo from './logo.svg';
import './App.css';
import 'bootstrap'
import 'react-bootstrap'
import Header from "./Header";
import Login from "./Login";

function App() {
  return (
      <div className="App container py-3">
        <Header/>
        <Login/>
      </div>
  );
}

export default App;
