import React, { useState } from 'react';
import data from '../api/data';
import { FormData } from '../model/data';
import  './form.css';


interface FormProps {
  onSubmit: (data: FormData) => void;
}

const Form: React.FC<FormProps> = ({ onSubmit }) => {
  const [formData, setFormData] = useState<FormData>({ code: 0, value: '' });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const dataArray = [formData];
    data.Add(dataArray)
    .then(() => {
      console.log('Данные успешно отправлены');
    })
    .catch((error) => {
      console.error('Ошибка при отправке данных:', error);
    });
  };

  return (
    <form onSubmit={handleSubmit} className="form-container">
      <label htmlFor="code">Code:</label>
      <input
        type="number"
        id="code"
        name="code"
        value={formData.code}
        onChange={handleChange}
        required
      /><br />
      <label htmlFor="value">Value:</label>
      <input
        type="text"
        id="value"
        name="value"
        value={formData.value}
        onChange={handleChange}
        required
      /><br />
      <button type="submit">Сохранить</button>
    </form>
  );
};

export default Form;