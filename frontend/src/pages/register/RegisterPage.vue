<script setup lang="ts">
  import WholePageForm from "../../components/common/WholePageForm.vue"
  import { defineModel } from "vue"
  import { register } from "../../auth/register"
  import { routes } from "../../routes"

  const username = defineModel("username", { type: String })
  const password = defineModel("password", { type: String })
  const passwordRepeat = defineModel("passwordRepeat", { type: String })

  const rules = {
    required: (value?: string) => !!value || "Field is required",
    matchesPassword: (value?: string) =>
      value === password.value || "Passwords do not match",
  }

  const onRegister = () => {
    if (
      !username.value ||
      !password.value ||
      !passwordRepeat.value ||
      rules.matchesPassword(passwordRepeat.value) !== true
    ) {
      return
    }

    register(username.value, password.value)
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
    <v-text-field
      v-model="passwordRepeat"
      class="text-field"
      label="Repeat Password"
      type="password"
      :rules="[rules.required, rules.matchesPassword].flat()"
    />
    <v-btn class="button" type="submit" @click="onRegister">REGISTER</v-btn>
    <router-link :to="routes.login">Log in</router-link>
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
