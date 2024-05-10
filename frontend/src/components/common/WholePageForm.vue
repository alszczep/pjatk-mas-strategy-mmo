<script setup lang="ts"></script>

<template>
  <div class="page-wrapper">
    <div class="form-card">
      <slot />
    </div>
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }

  .form-card {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    max-width: 400px;
    width: 400px;
    gap: 8px;
  }
</style>
