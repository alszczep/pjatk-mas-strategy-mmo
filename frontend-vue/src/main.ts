import './styles.scss';

import { createApp } from 'vue';
import App from './app/App.vue';
import { vuetifyConfig } from './vuetify.config';

const app = createApp(App);

app.use(vuetifyConfig);
app.mount('#root');
