import "./styles.scss"

import { createApp } from "vue"
import App from "./app/App.vue"
import { vuetifyConfig } from "./vuetify.config"
import { router } from "./routes"

const app = createApp(App)

app.use(vuetifyConfig)
app.use(router)

app.mount("#root")
