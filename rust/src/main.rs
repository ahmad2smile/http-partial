#![feature(proc_macro_hygiene, decl_macro)]

use rocket::get;
use rocket::response::stream::TextStream;
use rocket::routes;
use rocket::tokio::time::{sleep, Duration};
use rocket::{build, launch};

#[get("/")]
async fn index() -> TextStream![std::string::String] {
    // NOTE: As this directly doesn't allow setting header, browser caches this under certain size
    // Can be done hacking around `impl Response` for `TextStream` for future

    // NOTE: Could not found any way without streams
    TextStream! {
        yield "[".to_string();
        let max = 5;

        for i in 0..=max {
            let comma = if i != max { ", " } else { "" };
            sleep(Duration::from_millis(1000 as u64)).await;
            yield format!("{{ Item: {} }}{}",i as u64, comma);
        }

        yield "]".to_string();
    }
}

#[launch]
fn rocket() -> _ {
    build().mount("/", routes![index])
}
