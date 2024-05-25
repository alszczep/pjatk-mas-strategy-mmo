<template>
  <v-layout>
    <router-view name="NavBar" />
    <div class="default-layout">
      <router-view />
    </div>
  </v-layout>
</template>

<style scoped>
  .default-layout {
    padding: 72px 8px 8px;
    height: calc(100vh);
    width: 100%;
  }
</style>
