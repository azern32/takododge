FROM postgres:latest

# Comment
RUN echo 'we are running some # of cool things'

# Download & install Rust's cargo
RUN curl https://sh.rustup.rs -sSf | sh

# Initialize pgrx
RUN cargo install --locked cargo-pgrx && cargo pgrx init