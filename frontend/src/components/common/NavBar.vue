<script setup lang="ts">
  import { logOut } from "../../auth/logOut"
  import { routes } from "../../routes"
</script>

<template>
  <v-app-bar :elevation="2">
    <div class="content">
      <div>
        <router-link
          :to="routes.game.village.withParam(routes.game.village.paramDefault)"
          ><v-btn to="/">YOUR VILLAGE</v-btn></router-link
        >
      </div>
      <v-btn @click="logOut">LOG OUT</v-btn>
    </div>
  </v-app-bar>
</template>

<style scoped>
  .content {
    display: flex;
    justify-content: space-between;
    width: 100%;
    padding: 0 16px;
  }
</style>
