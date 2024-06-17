import { useToast } from "vue-toast-notification"
import { authTokenKey } from "."
import { registerEndpoint, villageIdByOwnerEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"

export const register = async (username: string, password: string) => {
  const $toast = useToast()

  const result = await registerEndpoint(username, password)
  if (result.error) {
    $toast.error(result.error)
    return
  }

  localStorage.setItem(authTokenKey, result.result!)
  const villageId = await villageIdByOwnerEndpoint()
  router.push(routes.game.village.withParam(villageId))
}
