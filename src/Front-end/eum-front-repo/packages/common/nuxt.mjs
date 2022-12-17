import { join, dirname } from 'pathe'
import { defineNuxtModule } from '@nuxt/kit'
import { fileURLToPath } from 'url'

const __dirname = dirname(fileURLToPath(import.meta.url))

export default defineNuxtModule({
    hooks: {
        "components:dirs"(dirs) {
            dirs.push({
                path: join(__dirname, 'components'),
                prefix: 'eum'
            })
        }
    }
})