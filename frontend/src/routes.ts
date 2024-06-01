import {
  createRouter,
  createWebHistory,
  type RouteLocationNormalized,
} from "vue-router"

import NavBar from "./components/common/NavBar.vue"
import LoginPage from "./pages/LoginPage.vue"
import RegisterPage from "./pages/register/RegisterPage.vue"
import GamePage from "./pages/game/GamePage.vue"
import VillagePage from "./pages/game/village/VillagePage.vue"
import { isLoggedIn } from "./auth/isLoggedIn"

export const routes = {
  login: {
    index: "/",
  },
  register: {
    index: "/register",
  },
  game: {
    index: "/game",
    village: {
      index: "/game/village",
      param: "villageId",
      withParam: (villageId: string) => `/game/village/${villageId}`,
      paramDefault: "owner",
    },
  },
} as const

const getLastRoutePart = (route: `${string}/${string}`) =>
  route.split("/").at(-1) ?? ""
const getLastRoutePartWithParam = (route: {
  index: `${string}/${string}`
  param: string
}) => `${getLastRoutePart(route.index)}/:${route.param}`

const routesComponents = [
  { path: routes.login.index, component: LoginPage },
  {
    path: routes.register.index,
    component: RegisterPage,
  },
  {
    path: routes.game.index,
    component: GamePage,
    children: [
      {
        path: getLastRoutePartWithParam(routes.game.village),
        components: {
          default: VillagePage,
          NavBar,
        },
      },
    ],
  },
]

export const router = createRouter({
  history: createWebHistory(),
  routes: routesComponents,
})

router.beforeEach((to) => {
  const pathsWithoutAuth: string[] = [routes.login.index, routes.register.index]
  const isPathWithoutAuth = (p: RouteLocationNormalized) =>
    pathsWithoutAuth.includes(p.path)

  if (isPathWithoutAuth(to)) {
    if (isLoggedIn()) {
      return routes.game.village.withParam(routes.game.village.paramDefault)
    }
  } else {
    if (!isLoggedIn()) {
      return routes.login.index
    }
  }
})
