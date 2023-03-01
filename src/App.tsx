import axios, { AxiosResponse } from 'axios';
import { useEffect } from 'react';
import './App.css';
import { urlPeople } from './endpoints';

function App() {

  useEffect(() => {
    axios.get(urlPeople)
    .then((response: AxiosResponse<any>) => {
      console.log(response.data);
    })
  }, [])
  return (
    <>
      <h1>This is my first React App</h1>
      <p>Communicating with ASP.Net Core.</p>
    </>
  );
}

export default App;
