import React from "react";
import HomePage from "../Home/HomePage";
import { Routes ,Route } from 'react-router-dom';
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Configurator from "../Configurator";

const App = () => {
  return (
    <div className="container-fluid">
      <Routes>
        <Route exact path='/' element={<HomePage/>} />
        <Route exact path='/configurator' element={<Configurator/>} />
      </Routes>
      <ToastContainer autoClose={3000} hideProgressBar={true} />
    </div>
  );
};

export default App;

