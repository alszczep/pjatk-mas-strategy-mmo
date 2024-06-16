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
import BuildingPage from "./pages/game/village/building/BuildingPage.vue"

import { isLoggedIn } from "./auth/isLoggedIn"
import { villageIdByOwnerEndpoint } from "./api/endpoints"

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
      building: {
        index: "/game/village/:villageId/building",
        param: "placeInVillage",
        withParam: (villageId: string, placeInVillage: number) =>
          `/game/village/${villageId}/building/${placeInVillage}`,
      },
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
      // nested children do not work for some reason, maybe because of "components"
      {
        path: `${getLastRoutePartWithParam(routes.game.village)}/${getLastRoutePartWithParam(routes.game.village.building)}`,
        components: {
          default: BuildingPage,
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

router.beforeEach(async (to) => {
  const pathsWithoutAuth: string[] = [routes.login.index, routes.register.index]

  if (pathsWithoutAuth.includes(to.path)) {
    if (isLoggedIn()) {
      const villageId = await villageIdByOwnerEndpoint()
      return routes.game.village.withParam(villageId)
    }
  } else {
    if (!isLoggedIn()) {
      return routes.login.index
    }
  }
})
