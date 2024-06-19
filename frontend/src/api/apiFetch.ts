import { useToast } from "vue-toast-notification"
import { authTokenKey } from "../auth"
import { config } from "../config"

export const unknownErrorMessage = "Unknown error occurred"

export const apiFetch = async <T = undefined>(
  endpoint: string,
  method: "GET" | "POST" | "PUT" | "DELETE",
  body?: object,
  fetchOptions?: RequestInit,
  options?: {
    noErrorToast?: boolean
  },
): Promise<T> => {
  const url = new URL(endpoint, config.apiBaseUrl)
  const response = await fetch(url, {
    body: body ? JSON.stringify(body) : undefined,
    method,
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem(authTokenKey)}`,
      credentials: "include",
      ...fetchOptions?.headers,
    },
    ...fetchOptions,
  })

  if (response.status === 200) {
    return (await response.json()) as T
  }

  if (response.status < 400) {
    return undefined as T
  }

  const $toast = useToast()

  if (!options?.noErrorToast) {
    if (response.status === 401) {
      $toast.error("Unauthorized")
    } else {
      $toast.error(unknownErrorMessage)
    }
  }

  throw new Error(response.status.toString())
}
