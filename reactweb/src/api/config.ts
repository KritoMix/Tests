interface Config {
    BasePath?: string,
}

export class CurrentConfig {
    static currentConfig: Config = {
        BasePath: "http://localhost:7295/",
    };

    static init = () => {
        const config = {
            BasePath: 'http://localhost:7295',
        };
        CurrentConfig.set(config);
    };

    static set = (config: Config) => {
        CurrentConfig.currentConfig.BasePath = 'http://localhost:7295'; 
    };

    static get = () => ({
        BasePath: 'http://localhost:7295', 
    });
}