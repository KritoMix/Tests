import React, { useState, useEffect } from 'react';
import data from '../api/data'; 
import { DataModel } from '../model/data';
import  './form.css';

const List: React.FC = () => {
  const [entities, setEntities] = useState<DataModel[]>([]);
  const [codeFilter, setCodeFilter] = useState(0);

  useEffect(() => {
    fetchData(); 
  }, []); 

  const fetchData = () => {
    data.GetAll(codeFilter) 
      .then((response) => {
        setEntities(response); 
      })
      .catch((error) => {
        console.error('Ошибка при получении данных:', error);
      });
    };

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    fetchData();
    };

  return (
        <div>
        <h2>Список объектов</h2>
        <form onSubmit={handleSubmit} className="form-container">
            <label htmlFor="codeFilter">Code Filter:</label>
            <input
                type="number"
                id="codeFilter"
                value={codeFilter}
                onChange={(e) => setCodeFilter(parseInt(e.target.value))}
                required
            />
            <button type="submit">Поиск</button>
        </form>
        <ul>
            {entities.map((entity, index) => (
                <li key={index}>Code: {entity.code}, Value: {entity.value}</li>
            ))}
        </ul>
        </div>
    );
};

export default List;