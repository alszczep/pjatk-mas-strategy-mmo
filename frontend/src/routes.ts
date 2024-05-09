import { createMemoryHistory, createRouter } from "vue-router"

import LoginPage from "./pages/LoginPage.vue"

export const routes = {
  login: "/",
}

const routesComponents = [{ path: routes.login, component: LoginPage }]

export const router = createRouter({
  history: createMemoryHistory(),
  routes: routesComponents,
})
