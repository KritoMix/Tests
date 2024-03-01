
import axios from "axios";
import {CurrentConfig} from './config';
import { DataModel, FormData } from "../model/data";

const data =  {
  GetAll: (codeFilter: number) => {
    return new Promise<DataModel[]>((resolve, reject) => { // Возвращаем промис здесь
      let config = CurrentConfig.get();
      axios.get(`${config.BasePath}/api/Data/getdata?codeFilter=${codeFilter}`).then(
        response => {
          if (response && response.data) {
            resolve(response.data); // Разрешаем промис с данными
          } else {
            reject("Ошибка: ответ сервера не содержит данных");
          }
        },
        error => {
          let errorMessage = error.response ? error.response.data : "Не удалось выполнить запрос";
          reject(errorMessage); // Отклоняем промис с сообщением об ошибке
        }
      );
    })
  },
  Add: (model: FormData[]) => {
    return new Promise<void>((resolve, reject) => { // Возвращаем промис здесь
      let config = CurrentConfig.get();
      axios.post(`${config.BasePath}/api/Data/addData`, model).then(
        response => {
          if (response && response.data) {
            resolve(response.data); // Разрешаем промис с данными
          } else {
            reject("Ошибка: ответ сервера не содержит данных");
          }
        },
        error => {
          let errorMessage = error.response ? error.response.data : "Не удалось выполнить запрос";
          reject(errorMessage); // Отклоняем промис с сообщением об ошибке
        }
      );
    });
  },
}

export default data;


/*
const fetchData = async () => {
  try {
    var response = await fetch('https://localhost:7295/api/Data/getdata', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
        });
    return response.data;
  } catch (error) {
    console.error('There was a problem with your fetch operation:', error);
    return null;
  }
};

export { fetchData };
*/