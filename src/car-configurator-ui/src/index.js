import React from 'react';
import { BrowserRouter } from "react-router-dom";
import ReactDOM from "react-dom/client";
import './index.css';
import configureStore from "./redux/configureStore";
import { Provider as ReduxProvider } from "react-redux";
import App from './components/App';

const store = configureStore();

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <ReduxProvider store={store}>
    <React.StrictMode>
      <BrowserRouter>
      <App />
    </BrowserRouter>
    </React.StrictMode>
  </ReduxProvider>);
