import "./styles.scss"

import { createApp } from "vue"
import App from "./app/App.vue"
import { vuetifyConfig } from "./vuetify.config"
import { router } from "./routes"
import ToastPlugin from "vue-toast-notification"
//import 'vue-toast-notification/dist/theme-default.css';
//import 'vue-toast-notification/dist/theme-sugar.css';
import "vue-toast-notification/dist/theme-bootstrap.css"

const app = createApp(App)

app.use(vuetifyConfig)
app.use(router)
app.use(ToastPlugin)

app.mount("#root")
