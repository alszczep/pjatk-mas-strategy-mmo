<script setup lang="ts">
  import { ref } from "vue"
  import { useInterval } from "@vueuse/core"

  type Item = {
    name: string
    finishTimestamp: number
    infoColumn: string
  }

  const { title, infoColumnTitle, items, onFinish } = defineProps<{
    title: string
    infoColumnTitle: string
    items: Item[]
    onFinish: () => Promise<void>
  }>()

  const currentTimestamp = ref(new Date().getTime())
  useInterval(1000, {
    callback: () => {
      currentTimestamp.value = new Date().getTime()
    },
  })

  let refreshTimestamps: number[] = []

  const handleRefresh = async (finishTimestamp: number) => {
    if (refreshTimestamps.includes(finishTimestamp)) {
      return
    }

    refreshTimestamps.push(finishTimestamp)
    await onFinish()
    refreshTimestamps = refreshTimestamps.filter(
      (timestamp) => timestamp !== finishTimestamp,
    )
  }

  const headers = [
    {
      key: "name",
      value: "name",
      sortable: false,
    },
    {
      key: "infoColumn",
      value: "infoColumn",
      sortable: false,
      width: "160px",
    },
    {
      key: "timeLeft",
      value: (item: Item) => {
        const diff = item.finishTimestamp - currentTimestamp.value
        if (diff < 0) {
          handleRefresh(item.finishTimestamp)
          return "-"
        }

        const seconds = Math.floor(diff / 1000)
        const minutes = Math.floor(seconds / 60)
        const hours = Math.floor(minutes / 60)

        const secondsString =
          seconds % 60 < 10 ? `0${seconds % 60}` : `${seconds % 60}`
        const minutesString =
          minutes % 60 < 10 ? `0${minutes % 60}` : `${minutes % 60}`
        const hoursString = hours < 10 ? `0${hours}` : hours

        return `${hoursString}:${minutesString}:${secondsString}`
      },
      sortable: false,
      width: "120px",
    },
    {
      key: "finishTime",
      value: (item: Item) => new Date(item.finishTimestamp).toLocaleString(),
      sortable: false,
      width: "200px",
    },
  ]
</script>

<template>
  <div class="wrapper">
    <div>{{ title }}</div>
    <v-data-table
      :items="items"
      :headers="headers"
      density="compact"
      hide-default-footer
      items-per-page="99999"
      no-data-text="No items in the queue"
    >
      <!-- setting text on headers array doesn't seem to work -->
      <!-- eslint-disable-next-line vue/valid-v-slot -->
      <template #header.name="">
        {{ "Name" }}
      </template>
      <!-- eslint-disable-next-line vue/valid-v-slot -->
      <template #header.infoColumn="">
        {{ infoColumnTitle }}
      </template>
      <!-- eslint-disable-next-line vue/valid-v-slot -->
      <template #header.timeLeft="">
        {{ "Time left" }}
      </template>
      <!-- eslint-disable-next-line vue/valid-v-slot -->
      <template #header.finishTime="">
        {{ "Finish time" }}
      </template>
    </v-data-table>
  </div>
</template>

<style scoped>
  .wrapper {
    width: 100%;
  }
</style>
