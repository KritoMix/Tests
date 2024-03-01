const path = require('path');
const { override, addBabelInclude, addEslintLoader, addWebpackLoader } = require('customize-cra');

module.exports = override(
  // Включить Babel-конфигурацию
  addBabelInclude([
    // Путь к вашим исходным файлам TypeScript
    // Добавьте сюда пути к вашим TS и TSX файлам
    path.resolve(__dirname, 'src'),
  ]),
  // Включить ESLint конфигурацию
  addEslintLoader({
    // Путь к вашему файлу .eslintrc
    // Укажите путь к вашему конфигу ESLint здесь
    eslintOptions: {
      configFile: path.resolve(__dirname, '.eslintrc'),
    },
  }),
  // Настройка загрузчика ts-loader
  addWebpackLoader({
    test: /\.(ts|tsx)$/,
    loader: 'ts-loader',
    options: {
      // Ваши опции ts-loader, если нужно
    },
  }),
);