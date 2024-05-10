<script setup lang="ts">
  import WholePageForm from "../components/common/WholePageForm.vue"
  import { defineModel } from "vue"
  import { logIn } from "../auth/logIn"
  import { routes } from "../routes"

  const username = defineModel("username", { type: String })
  const password = defineModel("password", { type: String })

  const rules = {
    required: (value?: string) => !!value || "Field is required",
  }

  const onLogin = () => {
    if (!username.value || !password.value) return
    logIn(username.value, password.value)
  }
</script>

<template>
  <WholePageForm>
    <v-text-field
      v-model="username"
      class="text-field"
      label="Username"
      :rules="[rules.required]"
    />
    <v-text-field
      v-model="password"
      class="text-field"
      label="Password"
      type="password"
      :rules="[rules.required]"
    />
    <v-btn class="button" @click="onLogin">LOG IN</v-btn>
    <router-link :to="routes.register">Register</router-link>
  </WholePageForm>
</template>

<style scoped>
  .text-field {
    width: 100%;
  }

  .button {
    width: 100%;
  }
</style>
