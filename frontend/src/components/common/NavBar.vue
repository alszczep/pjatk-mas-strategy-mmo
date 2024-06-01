<script setup lang="ts">
  import { logOut } from "../../auth/logOut"
</script>

<template>
  <v-app-bar :elevation="2">
    <div class="content">
      <div />
      <v-btn @click="logOut">LOG OUT</v-btn>
    </div>
  </v-app-bar>
</template>

<style scoped>
  .content {
    display: flex;
    justify-content: space-between;
    width: 100%;
  }
</style>
