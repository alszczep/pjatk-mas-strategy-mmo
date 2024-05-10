import {
  createRouter,
  createWebHistory,
  type RouteLocationNormalized,
} from "vue-router"

import LoginPage from "./pages/LoginPage.vue"
import RegisterPage from "./pages/register/RegisterPage.vue"
import VillagePage from "./pages/village/VillagePage.vue"
import { isLoggedIn } from "./auth/isLoggedIn"

export const routes = {
  login: "/",
  register: "/register",
  village: "/village",
}

const routesComponents = [
  { path: routes.login, component: LoginPage },
  {
    path: routes.register,
    component: RegisterPage,
  },
  { path: routes.village, component: VillagePage },
]

export const router = createRouter({
  history: createWebHistory(),
  routes: routesComponents,
})

router.beforeEach((to) => {
  const pathsWithoutAuth = [routes.login, routes.register]
  const isPathWithoutAuth = (p: RouteLocationNormalized) =>
    pathsWithoutAuth.includes(p.path)

  if (isPathWithoutAuth(to)) {
    if (isLoggedIn()) {
      return routes.village
    }
  } else {
    if (!isLoggedIn()) {
      return routes.login
    }
  }
})
