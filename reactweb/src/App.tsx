import React from 'react';
import  data  from './api/data';
import {CurrentConfig} from "./api/config"
import Form from './screens/form';
import List from './screens/list';

function App() {
  CurrentConfig.init();
  const handleSubmit = (formData: { code: number; value: string }) => {
    // Обработка данных формы
    console.log(formData);
  };

 
  return (
      <div>
        <h1>Добавить объект</h1>
        <Form onSubmit={handleSubmit} />
        <List/>
      </div>
  );
}

export default App;
/*
interface Entity {
  id: number;
  code: number;
  value: string;
}

interface Props {
  // объявите типы для ваших пропсов
}

interface State {
  code: number;
  value: string;
  entities: Entity[];
}

class App extends React.Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = {
      code: 0,
      value: '',
      entities: []
    };
  }

  componentDidMount() {
    this.fetchData();
  }

  fetchData = async () => {
    try {
      const response = await data.GetAll(0);
     // this.setState({ entities: response });
    } catch (error) {
      console.error('Ошибка при получении данных:', error);
    }
  };
 
  handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    
  };
  
  render() {
    const { code, value, entities } = this.state;

    return (
      <div>
        <h1>Добавить объект</h1>
        <form onSubmit={this.handleSubmit}>
          <label htmlFor="code">Code:</label>
          <input
            type="number"
            id="code"
            name="code"
            value={code}
            onChange={(e) => this.setState({ code: parseInt(e.target.value) })}
            required
          /><br />
          <label htmlFor="value">Value:</label>
          <input
            type="text"
            id="value"
            name="value"
            value={value}
            onChange={(e) => this.setState({ value: e.target.value })}
            required
          /><br />
          <button type="submit">Сохранить</button>
        </form>
        <div>
          <h2>Список объектов</h2>
          <ul>
            {entities.map((entity, index) => (
              <li key={index}>Code: {entity.code}, Value: {entity.value}</li>
            ))}
          </ul>
        </div>
      </div>
    );
  }
}


export default App;

*/