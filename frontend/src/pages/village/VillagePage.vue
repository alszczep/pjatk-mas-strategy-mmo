<script setup lang="ts">
  import { logOut } from "../../auth/logOut"
</script>

<template>
  <div class="page-wrapper">
    <v-btn @click="logOut">LOG OUT</v-btn>
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }
</style>
