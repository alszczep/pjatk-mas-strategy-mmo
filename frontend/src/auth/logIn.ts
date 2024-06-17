import { useToast } from "vue-toast-notification"
import { authTokenKey } from "."
import { loginEndpoint, villageIdByOwnerEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"
import { unknownErrorMessage } from "../api/apiFetch"

export const logIn = async (username: string, password: string) => {
  const $toast = useToast()

  try {
    const token = await loginEndpoint(username, password)
    localStorage.setItem(authTokenKey, token.token)
  } catch (error: any) {
    if (error?.message === "401") {
      $toast.error("Invalid username or password")
      return
    }
    $toast.error(unknownErrorMessage)
  }

  const villageId = await villageIdByOwnerEndpoint()
  router.push(routes.game.village.withParam(villageId))
}
