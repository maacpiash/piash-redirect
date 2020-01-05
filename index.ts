import express, { Request, Response } from 'express'
import cors from 'cors'
import { config } from 'dotenv'
import { MongoClient } from 'mongodb'

config()

const LISTEN_PORT = process.env.LISTEN_PORT || 4100
const CONNECTIONSTRING = process.env.CONNECTIONSTRING
const BASE_URL = 'https://www.maacpiash.com'

const app = express().use(cors())

const mongoOptions = {
  useNewUrlParser: true,
  useUnifiedTopology: true,
}

app.get('/', (req: Request, res: Response) => {
  res.redirect(BASE_URL)
})

app.get('/:ShortKey', async (req: Request, res: Response) => {
  const { ShortKey } = req.params
  let url = BASE_URL
  if (CONNECTIONSTRING) {
    const client = await MongoClient.connect(CONNECTIONSTRING, mongoOptions)
    const db = await client
      .db('piash-redirect')
      .collection('shortcuts')
      .find({ ShortKey })
      .toArray()
    url = (db && db[0] && db[0].RealUrl) || BASE_URL
  }
  res.redirect(url)
})

app.listen(LISTEN_PORT, () =>
  console.log(`Server started on port ${LISTEN_PORT}`),
)
